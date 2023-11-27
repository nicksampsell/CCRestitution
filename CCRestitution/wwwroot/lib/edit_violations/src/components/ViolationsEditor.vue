<script>
import axios from "axios";
import IndividualViolation from "./IndividualViolation.vue";

export default {
	components: {
		IndividualViolation
	},
	props: ['ticketId'],
	data() {
		return {
			allViolations: {},
			error: ""
		}
	},
	mounted() {

		//axios.defaults.baseURL = 'https://localhost:44388'; //no trailing slash
		axios.defaults.withCredentials = true;

		var vm = this;
		
		axios({
			method: 'get',
			url: '/api/TicketViolations/ByTicket/' + this.ticketId,
			withCredentials: true
		})
		.then(function(response)
		{
			vm.allViolations = response.data;
		})
		.catch(function(error)
		{
			vm.error ="There was a problem loading the violations for this request.  Please try reloading the page.  If the problem persists, please contact the IT department.";
		});
	}
}
</script>

<template>
	<div class="wrapper" v-if="error == ''">
		<IndividualViolation v-for="v in allViolations"
		:id="v.id"
		:ticket-id="ticketId" 
		:violation-object="v"/>
	</div>
	<div class="wrapper" v-else>{{error}}</div>
</template>

<style>

</style>