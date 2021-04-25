
<template>
  
  <div>
   
    <b-form-input v-model="Name" type="text" placeholder="Введите имя"></b-form-input>
    <div class="mt-2"></div>

    <b-form-input v-model="surname" type="text" placeholder="Введите Фамилию"></b-form-input>
    <div class="mt-2"></div>

    <b-form-input v-model="fatherland" type="text" placeholder="Отчество"></b-form-input>
    <div class="mt-2"></div>
  
  
    <b-form-input v-model="number" type="password" placeholder="Введите номер телефона"></b-form-input>
    <div class="mt-2"></div>

    <b-form-input v-model="message" type="text" placeholder="Введите текст сообщения"></b-form-input>
    <div class="mt-2"></div>
    <b-button @click="addInfo" variant="success">Отправить</b-button>
  </div>
</template>


  

<script>
import axios from 'axios'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
const baseURL = "http://localhost:3000/info"

export default {
    data() {
      return {
        fatherland: '',
        surname: '',
        Name: '',
        number: '',
        message: '',
        info: []
        
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
methods: {
async addInfo() {
    const res = await axios.post(baseURL, { name: this.Name, usrName: this.surname, fatherland: this.fatherland, phoneNumber: this.number, textMessage: this.message})
     this.info = [...this.info, res.data]
     this.Name = '',
     this.fatherland = '',
     this.surname = '',
     this.number = '',
     this.message = ''
    }
  }
}

  


</script>

