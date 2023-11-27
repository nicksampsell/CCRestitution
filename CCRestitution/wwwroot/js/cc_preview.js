var url = '';

pdfjsLib.GlobalWorkerOptions = './pdf.worker.js';

var pdfDoc = null,
  pageNum = 1,
  pageRendering = false,
  pageNumPending = null,
  scale = 1,
  canvas = document.getElementById('the-canvas'),
  ctx = canvas.getContext('2d');

var next = document.getElementById('next');
var prev = document.getElementById('prev');

function renderPage(num) {
	pageRendering = true;
	// Using promise to fetch the page
	pdfDoc.getPage(num).then(function(page) {
	  var viewport = page.getViewport({ scale: scale, });
	  // Support HiDPI-screens.
	  var outputScale = window.devicePixelRatio || 1;

	  canvas.width = Math.floor(viewport.width * outputScale);
	  canvas.height = Math.floor(viewport.height * outputScale);
	  //canvas.style.width = Math.floor(viewport.width) + "px";
	  //canvas.style.height =  Math.floor(viewport.height) + "px";

	  var transform = outputScale !== 1
	    ? [outputScale, 0, 0, outputScale, 0, 0]
	    : null;

	  // Render PDF page into canvas context
	  var renderContext = {
	    canvasContext: ctx,
	    transform: transform,
	    viewport: viewport,
	  };
	  var renderTask = page.render(renderContext);

	  // Wait for rendering to finish
	  renderTask.promise.then(function () {
	    pageRendering = false;
	    if (pageNumPending !== null) {
	      // New page rendering is pending
	      renderPage(pageNumPending);
	      pageNumPending = null;
	    }
	  });
	});

	document.getElementById('page_num').textContent = num;
}

function queueRenderPage(num) {
    if (pageRendering) {
      pageNumPending = num;
    } else {
      renderPage(num);
    }

    if(num <= 1)
    {
    	toggleDisabled(prev);
    }
    else
    {
    	toggleDisabled(prev, false);
    }

    if(num >= pdfDoc.numPages)
    {
    	toggleDisabled(next);
    }
    else
    {
    	toggleDisabled(next, false);
    }
  }

function onPrevPage() 
{ 
	if(pageNum <= 1)
	{
		return;
	}

	pageNum--;
	queueRenderPage(pageNum);
}
prev.addEventListener('click',onPrevPage);

function onNextPage()
{
	if(pageNum >= pdfDoc.numPages)
	{
		return;
	}
	pageNum++;
	queueRenderPage(pageNum);
}
next.addEventListener('click',onNextPage);


document.getElementById('forceSend').addEventListener('show.bs.modal', event => {
	  url = event.relatedTarget.getAttribute('data-load-pdf');
	  document.getElementById('shouldPreviewBtn').setAttribute('data-load-pdf',url);
})

document.getElementById('previewPDF').addEventListener('show.bs.modal', event => {
	url = event.relatedTarget.getAttribute('data-load-pdf');
	ticketId = event.relatedTarget.getAttribute('data-ticket-id');

	axios.get('/api/Letters/Generate/' + ticketId)
		.then(function (result) {
			console.log(result);
			var loadingTask = pdfjsLib.getDocument(url);

			loadingTask.promise.then(function (pdfDoc_) {
				pdfDoc = pdfDoc_;
				document.getElementById('page_count').textContent = pdfDoc.numPages;
				renderPage(pageNum);

				if (pdfDoc.numPages <= 1) {
					toggleDisabled(next, true);
					toggleDisabled(prev, true);
				}
			});
		}).catch(function (error) {
			console.log(error);
		});
	


});

function toggleDisabled(object, force = null)
{
	if(force != null)
	{
		return object.disabled = force;
	}
	else
	{
		object.disabled = !object.disabled;
	}
}