<template>
  <div class="col-12 text-dark">
    <div class="row mybg justify-content-around">
      <div class="col-10">
        <h1>{{vaultData.name}}</h1>
        <h3>{{vaultData.description}}</h3>
      </div>
      <div class="col-1 p-3">
        <button class="btn btn-danger" @click="deleteThisVault()">X</button>
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
export default {
  name: "vault",
  props: ["vaultData", "vaultIndex"],
  mounted() {
    //this.$store.dispatch("")
  },
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteThisVault() {
      let id = this.vaultData.id;
      let index = this.vaultIndex;
      this.$store.dispatch("deleteVaultById", { id, index });
    }
  },

  components: {}
};
</script>


<style scoped>
.mybg {
  background-color: rgba(0, 0, 0, 0.2);
}
</style>