<template>
  <div class="vaults container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>These are your vaults</h1>
        <button @click="getVaults()">reveal</button>
      </div>
      <div class="col-12">
        <vault v-for="(vault, index) in vaults" :key="vault.id" :vaultData="vault" />
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "../components/Vault";
export default {
  name: "vaults",
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    getVaults() {
      this.$store.dispatch("getVaults");
    }
  },
  components: {
    Vault
  }
};
</script>

<style></style>
