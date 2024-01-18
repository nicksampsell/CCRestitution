using CCRestitution.Data;
using CCRestitution.Models;
using CCRestitution.ReportsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Linq.Expressions;

namespace CCRestitution.Area.Reports.Controllers
{
    [Area("Reports")]
    public class ReportsController : Controller
    {
        private readonly DataContext _context;
        private readonly DataContext _context2;

        public ReportsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {


            return View();
        }

        [HttpGet("GenerateReport/{reportId}")]
        public async Task<List<object>> GenerateReportQuery(int reportId)
        {
            var report = await _context.Reports
                .AsNoTracking()
                .Include(x => x.ReportCriteria)
                .Include(x => x.ReportFields)
                .Where(x => x.ReportId == reportId)
                .FirstOrDefaultAsync();

            if (report == null)
            {
                return new List<object>();
            }

            var entityType = GetEntityType(report.ModelName);

            if (entityType == null)
            {
                // Handle invalid model name
                return new List<object>();
            }

            // Use reflection to call Set dynamically
            var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)
                .MakeGenericMethod(entityType);
            var query = (IQueryable<object>)setMethod.Invoke(_context, null);

            // Include fields dynamically
            foreach (var field in report.ReportFields)
            {
                var propertyInfo = entityType.GetProperty(field.FieldName);
                if (propertyInfo != null)
                {
                    if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                    {
                        // Property is a navigation property
                        if (!string.IsNullOrEmpty(field.ModelName) && !string.IsNullOrEmpty(field.FieldName))
                        {
                            query = (IQueryable<object>?)query.Provider.CreateQuery(
                                Expression.Call(
                                    typeof(EntityFrameworkQueryableExtensions),
                                    "Include",
                                    new[] { entityType },
                                    query.Expression,
                                    Expression.Constant($"{field.ModelName}.{field.FieldName}")
                                )
                            );
                        }
                    }

                }
            }

            // Apply criteria dynamically
            foreach (var criteria in report.ReportCriteria)
            {
                var parameter = Expression.Parameter(entityType, "entity");
                var property = Expression.Property(parameter, criteria.Field);
                var constant = Expression.Constant(Convert.ChangeType(criteria.FieldValue, property.Type));
                var binaryExpression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda(binaryExpression, parameter);
                query = (IQueryable<object>?)query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        "Where",
                        new[] { entityType },
                        query.Expression,
                        lambda
                    )
                );
            }

            return await query.ToListAsync();
        }

        private Type GetEntityType(string modelName)
        {
            var entityType = _context.Model.GetEntityTypes()
                .FirstOrDefault(e => e.ClrType.Name == modelName);

            return entityType?.ClrType;
        }

    }
}

/**
 *             // Apply criteria dynamically
            var individualConditions = new List<Expression<Func<object, bool>>>();
            var parameter = Expression.Parameter(entityType, "entity");

            foreach (var criteria in report.ReportCriteria)
            {
                var property = Expression.Property(parameter, criteria.Field);
                var constant = Expression.Constant(Convert.ChangeType(criteria.FieldValue, property.Type));

                BinaryExpression binaryExpression;

                switch (criteria.Operator)
                {
                    case "Equals":
                        binaryExpression = Expression.Equal(property, constant);
                        break;
                    case "GT":
                        binaryExpression = Expression.GreaterThan(property, constant);
                        break;
                    case "LT":
                        binaryExpression = Expression.LessThan(property, constant);
                        break;
                    case "GTE":
                        binaryExpression = Expression.GreaterThanOrEqual(property, constant);
                        break;
                    case "LTE":
                        binaryExpression = Expression.LessThanOrEqual(property, constant);
                        break;
                    case "NotEqual":
                        binaryExpression = Expression.NotEqual(property, constant);
                        break;
                    default:
                        throw new InvalidOperationException($"Unsupported operator: {criteria.Operator}");
                }

                // Create a lambda expression for the individual condition
                var lambda = Expression.Lambda<Func<object, bool>>(binaryExpression, parameter);

                // Check if there are OR relationships specified
                if (!string.IsNullOrEmpty(criteria.OrFields))
                {
                    // If OR fields are specified, create a separate lambda for each OR condition
                    var orFields = criteria.OrFields.Split(',');
                    var orConditions = orFields.Select(orField =>
                    {
                        var orParameter = Expression.Parameter(entityType, "entity");
                        var orProperty = Expression.Property(orParameter, orField);
                        var orConstant = Expression.Constant(Convert.ChangeType(criteria.FieldValue, orProperty.Type));
                        var orBinaryExpression = Expression.Equal(orProperty, orConstant);
                        return Expression.Lambda<Func<object, bool>>(orBinaryExpression, orParameter);
                    });



                    // Combine OR conditions with OR relationship
                    var orCondition = orConditions.Aggregate(
                        (current, next) => Expression.Lambda<Func<object, bool>>(
                            Expression.OrElse(
                                Expression.Invoke(current, parameter),
                                Expression.Invoke(next, parameter)
                            ),
                            parameter
                        )
                    );


                    // Combine individual condition and OR condition with AND relationship
                    var combinedCondition = Expression.Lambda<Func<object, bool>>(
                        Expression.AndAlso(Expression.Invoke(lambda, parameter), Expression.Invoke(orCondition, parameter)),
                        parameter
                    );

                    individualConditions.Add(combinedCondition);
                }
                else
                {
                    // If no OR relationships are specified, add the individual condition directly
                    individualConditions.Add(lambda);
                }
            }
            // Combine all individual conditions with AND relationship
            var combinedConditions = individualConditions.Aggregate(
                (current, next) => Expression.Lambda<Func<object, bool>>(
                    Expression.AndAlso(
                        Expression.Invoke(current, parameter),
                        Expression.Invoke(next, parameter)
                    ),
                    parameter
                )
            );

            // Apply the combined conditions to the query
            query = (IQueryable<object>?)query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    "Where",
                    new[] { entityType },
                    query.Expression,
                    combinedConditions
                )
            );**/