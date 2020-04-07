<template>
  <div class="keep col-6">
    <div class="mybg">
      <div class="row justify-content-around">
        <div class="col-11">img u</div>
        <div class="col-11">
          <h5>{{keepData.name}}</h5>
        </div>
        <div class="col-11">{{keepData.description}}</div>
        <div class="col-3">
          views:
          <br />
          {{keepData.views}}
        </div>
        <div class="col-3">
          shares:
          <br />
          {{keepData.shares}}
        </div>
        <div class="col-3">
          keeps:
          <br />
          {{keepData.keeps}}
        </div>
      </div>

      <div class="row py-3 justify-content-around">
        <div class="col-3">
          <button class="btn btn-secondary btn-rounded">Keep</button>
        </div>
        <div class="col-3">
          <button class="btn btn-warning btn-rounded">Share</button>
        </div>
        <div class="col-3">
          <button class="btn btn-danger btn-rounded">X</button>
        </div>
      </div>
      <!-- <h1>test {{keepData.description}} {{keepData.name}}</h1> -->
    </div>

    <div class="row">
      <div class="col-12">
        <br />
      </div>
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
.mybg {
  background-color: rgba(0, 0, 0, 0.2);
}
</style>