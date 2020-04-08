<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <div class="col-6">
        <!-- <router-link to="/keeps"> -->
          <button class="btn btn-dark" @click="setShow('keeps')">See all the Keeps</button>
        <!-- </router-link> -->
      </div>
      <div class="col-6">
        <!-- <router-link to="/vaults"> -->
          <button class="btn btn-dark" @click="setShow('vaults')">See your Vaults</button>
        <!-- </router-link> -->
      </div>

      <div class="row" v-if="this.show === 'vaults'">
        <div class="col-12">
          <p>option 1: vaults</p>
        </div>
      </div>

      <div class="row" v-if="this.show === 'keeps'">
        <div class="col-12">
          <p>option 2: keeps</p>
        </div>
      </div>
    </div>

     <div class="row">
        <div class="col-12" v-if="this.show === ''">
          <p>option 3</p>
        </div>
      </div>
    </div>

    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
export default {
  mounted() {
    //this.$store.dispatch("setKeeps");
  },
  computed: {
    show() {
      return this.$store.state.show;
    }
  },
  methods: {
    setShow(show) {
      this.$store.dispatch("setShow", show);
    }
  }
};
</script>

<style></style>
