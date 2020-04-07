<template>
  <div class="keep">
    <div class="col-12">
      <h1>test {{keepData.description}} {{keepData.name}}</h1>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
  props: ["keepData"],
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
</style>