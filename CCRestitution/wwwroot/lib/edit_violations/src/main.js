import { createApp } from 'vue';
import violationsEditor from './components/ViolationsEditor.vue';
const root_element = document.getElementById('violationsEditor');

createApp(violationsEditor,{...root_element.dataset }).mount('#violationsEditor')
