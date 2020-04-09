<template>
  <div class="col-12 text-dark">
    <div class="row mybg justify-content-around">
      <div class="col-10">
        <h1>{{vaultData.name}}</h1>
        <h3>{{vaultData.description}}</h3>
        <!-- <button class="btn btn-secondary" @click="getVaultKeeps()">Populate Vaults</button> -->
      </div>
      <div class="col-1 p-3">
        <button class="btn btn-danger" @click="deleteThisVault()">X</button>
      </div>
      <div class="col-12">
        <div class="row">
          <keep
            v-for="(keep, index) in keeps"
            :key="keep.vaultKeepId"
            :keepData="keep"
            :keepIndex="index"
            :deleteKeep="'vault'"
            :vaultData="vaultData"
          />
        </div>
      </div>

      <!-- end row -->
    </div>
    <!-- end row -->

    <div class="row">
      <div class="col-12">
        <br />
      </div>
    </div>
  </div>
</template>



<script>
import Keep from "./Keep";

export default {
  name: "vault",
  props: ["vaultData", "vaultIndex"],
  mounted() {
    //debugger;
    //let vaultId = this.vaultData.id;
    // this.getVaultKeeps();
    this.$store.dispatch("getKeepsByVaultId", this.vaultData.id);
  },
  data() {
    return {};
  },
  computed: {
    keeps() {
      return this.$store.state.vaultKeeps[this.vaultData.id];
      //return this.$store.state.comments[this.taskData.id]
    }
  },
  methods: {
    deleteThisVault() {
      let id = this.vaultData.id;
      let index = this.vaultIndex;
      this.$store.dispatch("deleteVaultById", { id, index });
    },
    getVaultKeeps() {
      try {
        if (this.$auth.isAuthenticated) {
          this.$store.dispatch("getKeepsByVaultId", this.vaultData.id);
        }
      } catch (error) {
        console.error(error);
      }
    }
  },
  components: {
    Keep
  }
};
</script>


<style scoped>
.mybg {
  background-color: rgba(0, 0, 0, 0.2);
}
</style>