  
import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex);

let store = new Vuex.Store({
  state: {
    contacts: [],
    chats: [],
    currentUserChat: {}
  },
    FETCH_INFO({commit}) {
      return axios.get('http://localhost:3000/info')
        .then((info) => {
          commit('SET_INFO_TO_STORE', usrName)
  
        })
      }
    })
   

export default store;