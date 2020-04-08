import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    keeps: [],
    myKeeps: [],
    vaults: []
  },


  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setMyKeeps(state, myKeeps) {
      state.myKeeps = myKeeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },

  },



  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    getKeeps({ commit, dispatch }) {
      //  debugger
      api.get('keeps').then(res => {
        commit('setKeeps', res.data)
      })
    },


    async getMyKeeps({ commit, dispatch }) {
      // debugger
      try {
        api.get('keeps/myKeeps').then(res => {
          commit('setMyKeeps', res.data)
        })
      }
      catch (error) {
        console.error(error);
      }
    },

    async addKeep({ commit, dispatch }, newKeep) {
      //debugger
      try {
        api.post('keeps', newKeep)
          .then(serverBoard => {
            dispatch('getKeeps')
          })
      }
      catch (error) {
        console.error(error);
      }
    },


    async deleteKeepById({ commit, dispatch }, id) {
      //debugger
      try {
        let res = await api.delete("keeps/" + id)
        commit('setMyKeeps', res.data)
        dispatch('getKeeps')
      }
      catch (error) {
        console.error(error);
      }
    },





    getVaults({ commit, dispatch }) {
      //  debugger
      api.get('vaults').then(res => {
        commit('setVaults', res.data)
      })
    },



  }
});
