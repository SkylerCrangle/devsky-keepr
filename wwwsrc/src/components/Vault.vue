<template>
  <div class="col-12 text-dark mybg m-2">
    <h1>{{vaultData.name}}</h1>
    <h3>{{vaultData.description}}</h3>
  </div>
</template>



<script>
export default {
  name: "vault",
  props: ["vaultData"],
  mounted() {
    //this.$store.dispatch("")
  },
  data() {
    return {};
  },
  computed: {},
  methods: {},

  components: {}
};
</script>


<style scoped>
.mybg {
  background-color: rgba(0, 0, 0, 0.2);
}
</style>