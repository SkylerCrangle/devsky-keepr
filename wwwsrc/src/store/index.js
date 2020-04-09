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
    vaults: [],
    show: ""
  },


  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setMyKeeps(state, myKeeps) {
      state.myKeeps = myKeeps
    },
    addKeep(state, newKeep) {
      state.myKeeps.push(newKeep);
      if (!newKeep.IsPrivate) {
        state.keeps.push(newKeep)
      }
    },
    deleteKeep(state, index) {
      state.myKeeps.splice(index, 1)
    },
    deleteKeepHome(state, index) {
      state.keeps.splice(index, 1)
    },

    setVaults(state, vaults) {
      state.vaults = vaults
    },
    addVault(state, newVault) {
      state.vaults.push(newVault)
    },
    deleteVault(state, index) {
      debugger
      state.vaults.splice(index, 1)
    },

    setShow(state, show) {
      state.show = show
      console.log(show, state.show)
    },

  },



  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    setShow({ commit, dispatch }, show) {
      this.commit('setShow', show)
    },

    getKeeps({ commit, dispatch }) {
      api.get('keeps').then(res => {
        commit('setKeeps', res.data)
      })
    },
    async getMyKeeps({ commit, dispatch }) {
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
      try {
        api.post('keeps', newKeep)
          .then(serverBoard => {
            commit('addKeep', newKeep)
          })
      }
      catch (error) {
        console.error(error);
      }
    },
    async deleteKeepById({ commit, dispatch }, { id, index, from }) {
      try {
        let res = await api.delete("keeps/" + id)
        if (from == 'home') {
          commit('deleteKeepHome', index)
        }
        else if (from == 'dashboard') {
          commit('deleteKeep', index)
        }
      }
      catch (error) {
        console.error(error);
      }
    },


    getVaults({ commit, dispatch }) {
      api.get('vaults').then(res => {
        commit('setVaults', res.data)
      })
    },
    async addVault({ commit, dispatch }, newVault) {
      try {
        api.post('vaults', newVault)
          .then(r => {
            commit('addVault', r.data)
          })
      }
      catch (error) {
        console.error(error);
      }
    },
    async deleteVaultById({ commit, dispatch }, { id, index }) {
      try {
        let res = await api.delete("vaults/" + id)
        commit('deleteVault', index)
      }
      catch (error) {
        console.error(error);
      }
    },
    async storeKeepInVault({ commit, dispatch }, { keepId, vaultId, name, from }) {
      try {
        let res = await api.post("vaultkeeps", { keepId, vaultId })
        //find keep in store and increment keeps
        let keep = await api.get('keeps/' + keepId)
        let originalKeeps = keep.data.keeps
        let keeps = originalKeeps + 1
        let objToPost = {
          name: name,
          keeps: keeps
        }
        console.log(objToPost)
        let res2 = await api.put('keeps/incrk/' + keepId, objToPost)
        if (from == 'home') {
          dispatch('getKeeps')
        }
        else if (from == 'dashboard') {
          dispatch('getMyKeeps')
        }
      } catch (error) {
        console.error(error);
      }
    }



  }
});
