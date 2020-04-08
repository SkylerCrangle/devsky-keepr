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
      //debugger
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

    async addVault({ commit, dispatch }, newVault) {
      //debugger
      try {
        api.post('vaults', newVault)
          .then(serverBoard => {
            dispatch('getVaults')
          })
      }
      catch (error) {
        console.error(error);
      }
    },


    async deleteVaultById({ commit, dispatch }, id) {
      //debugger
      try {
        let res = await api.delete("vaults/" + id)
        commit('setVaults', res.data)
        dispatch('getVaults')
      }
      catch (error) {
        console.error(error);
      }
    },

    async storeKeepInVault({ commit, dispatch }, { keepId, vaultId, name }) {
      try {
        let res = await api.post("vaultkeeps", { keepId, vaultId })
        //find keep in store and increment keeps
        //debugger
        let keep = await api.get('keeps/' + keepId)
        let obj = keep.data
        let keepKeep = obj.keeps
        let keeps = keepKeep + 1
        let check = obj.isPrivate
        console.log(keeps)
        let objToPost = {
          name: name,
          keeps: keeps

        }
        console.log(objToPost)
        let res2 = await api.put('keeps/' + keepId, objToPost)
        console.log(res2.data)

        if (check) {
          dispatch('getMyKeeps')
        }
        else {
          dispatch('getKeeps')
        }
        //debugger

      } catch (error) {
        console.error(error);
      }
    }



  }
});
