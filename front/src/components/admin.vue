<template>
       
<div >
    <b-button pill variant="primary">10</b-button>
    <b-button pill variant="primary">20</b-button>
    <b-button pill variant="primary">30</b-button>
    

    <h3 v-for="info of info" :key="info.Id">  
        <hr >
        ID: {{info.id}}
     <br>
        ФИО: {{info.surName}} {{info.name}} {{info.patronymic}}
       
      <br> 
        Номер телефона: {{info.phoneNumber}}
        <br>
        Дата: {{info.date}}
        <hr>
    </h3>
        

</div>

  
</template>

<script>

import axios from 'axios';

const baseURL = "https://webapiapp.azurewebsites.net/api/userrequests"

export default {
    
  name: 'app',
  data() {
      
    return {

      info: [],
      todoName: '',
      
    }
  },
   
  async created() {
    try {
      const res = await axios.get(baseURL)

      this.info = res.data;
    } catch(e) {
      console.error(e)
    }
    
  },
  
}

  

</script>
<style scoped>

</style>
