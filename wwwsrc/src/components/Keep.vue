<template>
  <div class="keep col-12 col-sm-6 col-md-4 col-lg-3">
    <div class="mybg" v-bind:class="{ private: keepData.isPrivate}">
      <div class="row justify-content-around">
        <div class="col-11 py-3">
          <img class="img-fluid imgs" :src="keepData.img" />
        </div>
        <div class="col-11">
          <h5>{{keepData.name}}</h5>
        </div>
        <div class="col-11">{{keepData.description}}</div>
        <div class="row pt-5 pb-3">
          <div class="col-4">
            views:
            <br />
            {{keepData.views}}
          </div>
          <!-- <div class="col-1"></div> -->
          <div class="col-4">
            shares:
            <br />
            {{keepData.shares}}
          </div>
          <!-- <div class="col-1"></div> -->
          <div class="col-4">
            keeps:
            <br />
            {{keepData.keeps}}
          </div>
        </div>
      </div>

      <div class="row py-3 justify-content-around">
        <div class="col-3">
          <button class="btn btn-secondary btn-rounded">Keep</button>
        </div>
        <div class="col-3">
          <button class="btn btn-warning btn-rounded">Share</button>
        </div>

        <!-- help, where is my user id vs the creator userid? -->

        <div class="col-3" v-if="(keepData.UserId == keepData.UserId )">
          <button class="btn btn-danger btn-rounded" @click="deleteThisKeep()">X</button>
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
  methods: {
    deleteThisKeep() {
      let id = this.keepData.id;
      this.$store.dispatch("deleteKeepById", id);
    }
  },

  components: {}
};
</script>


<style scoped>
.mybg {
  background-color: rgba(0, 0, 0, 0.2);
}
.imgs {
  max-width: 100%;
  max-height: 100%;
}
.private {
  border-block-end-style: dotted;
  border-width: 10px;
  border-color: seagreen;
}
</style>