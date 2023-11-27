<script>
import 'vue-select/dist/vue-select.css';
import vSelect from 'vue-select';
import SaveBadge from './SaveBadge.vue';
import axios from 'axios';
import { isProxy, toRaw, nextTick } from 'vue';
import _ from 'lodash';

export default {
	components: {vSelect, SaveBadge },
	props: [
		'id',
		'violationObject',
		'ticketId',
		'userId'
	],
	data() {
		return {
			originalViolation: null,
			originalViolationId: null,
			overrideAction: "Nothing",
			overrideViolation: null,
			overrideViolationId: null,
			backupViolationOverride: null,
			backupViolationOverrideId: null,
			originalSpeed: null,
			speedZone: null,
			reduceSpeed: null,
			attachmentUrl: null,
			isSaved: false,
			isModified: false,
			showReduceSpeedForm: false,
			showOverrideForm: false,
			error_ajax: false,
			error_laws: false,
			isLoading: false,
			showLawSearch: false,
			allLaws: [],
			updatedViolation: "",
			updatedViolationId: 0,
			displaySpeedString: "",
		}
	},
	methods: {
		doSave() {
			axios({
				method: 'put',
				url: '/api/TicketViolations/' + parseInt(this.id,10),
				data: {
					id: this.id,
					ticketId: this.ticketId,
					violationId: this.originalViolationId,
					violationOverrideId: this.overrideViolationId,
					originalSpeed: this.originalSpeed,
					originalSpeedLimit: this.speedZone,
					originalSpeedOverride: this.reduceSpeed,
					overrideType: this.overrideAction
				},
				withCredentials: true
			})
			.then(response => {
				this.modified = false;
				this.isSaved = true;
				//console.log(response);
			})
			.catch(error => {
				this.error_ajax = true;
				this.modified = true;
				this.isSaved = false;
				//console.log(error);
			});
		},

		asyncFind(search, loading) {
			loading(true);

			axios.get('/Laws/AjaxFilter',{
					params: {
						'searchString': search
					}
				})
				.then(response => {
					this.allLaws = response.data.items;
				})
				.catch(error => {
					console.log(error);
				})
				.then(t => {
					loading(false);
				});

		},

		dropdownClose()
		{
			if(this.backupViolationOverride != null)
			{
				this.OverrideViolationModel = this.backupViolationOverride;
			}
		},

		toggleVisibility(event)
		{
			this.showLawSearch = this.showLawSearch;
		},

		acceptNumbersOnly(event) {

			if(event.target.classList.contains('speed-from'))
			{
				this.originalSpeed = event.target.value;
			}
			if(event.target.classList.contains('speed-to'))
			{
				this.reduceSpeed = event.target.value;
			}
			event.target.value = event.target.value.replace(/[^0-9.]/g, '').replace(/(\..*)\./g,'$1');
			this.isSaved = false;
			this.isModified = true;
		},

		shouldShowReduceSpeedForm(event = null) {
			nextTick(() => {
				if(this.overrideViolationModel != null && this.overrideViolationModel.includes("1180"))
				{
					this.showReduceSpeedForm = true;
				}
				else
				{
					this.showReduceSpeedForm = false;
				}
				this.shouldSave = true;
				this.isSaved = false;
			});
		},

		doChangeViolation(event) {

			var options = ['nothing','reduce','reject','covered'];
			var changeViolationType;

			if(!options.includes(event.target.value.toLowerCase()))
			{
				changeViolationType = 'Nothing';
			}
			else
			{
				changeViolationType = event.target.value;
			}

			if(changeViolationType == "Reduce")
			{
				this.showOverrideForm = true;
			}
			else
			{
				this.showOverrideForm = false;
			}
			this.isModified = true;
			this.isSaved = false;
			this.overrideAction = changeViolationType;

			if(changeViolationType == "Nothing" || changeViolationType == "Reject" || changeViolationType == "Covered")
			{
				nextTick(() => { this.doSave(); });
			}
			
		}	

	},
	mounted() {
		//axios.defaults.baseUrl = 'https://localhost:44388'; //no trailing slash
		axios.defaults.withCredentials = true;


		this.originalViolationId = this.violationObject.violation.id ?? null;
		this.originalViolation = this.violationObject.violation.displayFullLawName ?? null;
		this.overrideAction = this.violationObject.overrideType ?? "Nothing";

		if(this.violationObject.violationOverride != null)
		{
		
			this.overrideViolation = this.violationObject.violationOverride.displayFullLawName ?? null;
			this.overrideViolationId = this.violationObject.violationOverride.Id ?? null;
		}
		else
		{
			this.overrideViolation = null;
			this.overrideViolationId = null;
		}


		this.originalSpeed = this.violationObject.originalSpeed ?? null;
		this.speedZone = this.violationObject.originalSpeedLimit ?? null;
		this.reduceSpeed = this.violationObject.originalSpeedOverride ?? null;
		this.attachmentUrl = this.violationObject.attachmentUrl ?? null;

		if((this.overrideAction) && (this.overrideAction == "reduce" || this.overrideAction == "Reduce"))
		{
			this.showOverrideForm = true;

			if((this.overrideViolation && this.overrideViolation.includes("1180")) || this.reduceSpeed)
			{
				this.showReduceSpeedForm = true;
			}
		}

		this.backupViolationOverride = this.ViolationOverride;
		this.backupViolationOverrideId = this.ViolationOverrideId;

		if(this.originalViolation.includes("1180") && this.originalSpeed != "")
		{
			this.displaySpeedString = "(Accused Speed: " + this.originalSpeed + " MPH)";
		}

	},

	computed: {
		overrideViolationModel: {
			get() { return this.overrideViolation },
			set (value) { 

				this.overrideViolation = value;

				let rawData = value;
				if(isProxy(value))
				{
					rawData = toRaw(value);
					this.overrideViolation = rawData.displayFullLawName;
					this.overrideViolationId = rawData.id;
				}

				this.shouldShowReduceSpeedForm();
			}
		}
	}
}
</script>

<template>
	<div class="card" :class="overrideAction.toLowerCase()">
		<div class="card-header">
			<div class="d-flex justify-content-between align-items-center">
				<SaveBadge :is-saved="isSaved" class="me-2 savebadge" />
				<div class="flex-grow-1">
					{{originalViolation}}

					<small v-if="displaySpeedString != ''" class="text-secondary">
						{{displaySpeedString}}
					</small>
				</div>
				<div class="me-2 ms-2">
					<a :href="attachmentUrl" target="_blank" class="attachment-link btn btn-outline-primary btn-sm" v-if="attachmentUrl">
<i class="bi bi-paperclip"></i><small>View Attachment</small></a>
				</div>
				<div style="min-width: 150px;">
					<select class="form-select" @change="doChangeViolation" :value="overrideAction">
	                    <option>Nothing</option>
	                    <option>Reduce</option>
	                    <option>Reject</option>
	                    <option>Covered</option>
					</select>

				</div>
			</div>
		</div>
		<div class="card-body" v-if="showOverrideForm">
			<div class="d-flex justify-content-between align-items-center">
				<div class="flex-grow-1">
					<div class="row">

						<div class="d-flex justify-content-between align-items-center">
							<label class="form-label me-3">Override Violation:</label>
							<v-select 
							class="flex-grow-1 dynamicDropdown" 
							:options="allLaws" 
							v-model="overrideViolationModel" 
							label="displayFullLawName" 
							:reduce="law => `${law.displayFullLawName}`"
							@option:selected="(selected) => { this.overrideViolationModel = selected; }" 
							@search="asyncFind" />
<!-- not needed with other dropdown <a @click="toggleFormVisibility" class="cancelDropDown ms-3" title="Cancel">
<i class="bi bi-x-square-fill"></i></a> -->

						</div>
					</div>
					<div class="d-flex mt-3 align-items-center expando-row">
						<div v-if="showReduceSpeedForm" class="flex-grow-1">
							<div class="d-flex justify-content-between align-items-center reduce_speed ps-5">
								<p>Reduce speed from 
								<input class="form-control speed-from" type="number" min="0" max="200" :value="originalSpeed" @input="acceptNumbersOnly"/> 
								in <select class="form-select speed-zone" :value="speedZone" @input="event => this.speedZone = event.target.value">
										<option></option>
										<option v-for="n in 13">{{n*5}}</option>
									</select> MPH Zone 
								to <input class="form-control speed-to" type="number" min="0" max="200" @input="acceptNumbersOnly"  
								:value="reduceSpeed"/></p>
							</div>
						</div>
						<div v-if="shouldSave">
							<button @click.prevent="doSave" class="btn btn-success float-end">Save Changes</button>
						</div>
					</div>
				</div>
			</div>

		</div>
		<div class="card-footer error" v-if="error_ajax">
			There was a problem saving this violation.  Please make a note of your changes and try reloading your page.  If this problem persists, please contact the IT department.
		</div>
		<div class="card-footer error" v-if="error_laws">
			There was a problem loading the NYS laws.  Please reload the page and try again.  If this problem persists, please contact the IT department.
		</div>		
	</div>
</template>

<style>
.form-label
{
	white-space: nowrap;
}
.reduce_speed .form-control, .reduce_speed .form-select
{
	display: inline-block;
}
.speed-from, .speed-to, .speed-zone
{
	width: 100px;
}
.attachment-link
{
	display: inline-block;
	text-align: center;
}
.small svg
{
	width: 24px;
	height: 24px;
}
.small span
{
	display: inline;
}
.expando-row div:only-child
{
	width: 100%;
}
.savebadge 
{
	margin-left: -.25em;
}
.cancelDropDown
{
	color: var(--bs-danger);
	cursor: pointer;
}
.card.covered .card-header
{
	background-color: var(--bs-success-bg-subtle);
}
.card.rejected .card-header
{
	background-color: var(--bs-success-bg-subtle);
}
.card.reduce .card-header
{
	background-color: var(--bs-warning-bg-subtle);
}
.dynamicDropdown
{
	width: 100%;
}
</style>