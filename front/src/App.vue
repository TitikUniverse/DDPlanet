<template>
  <div id="app">
    <div id="nav " >
      <b-button to="/forms" variant="success">Создать форму</b-button>
      <b-button to="/admin" variant="info">Я администратор</b-button>
    </div>
    <router-view/>
  </div>
</template>
<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
export default {
  
}
</script>