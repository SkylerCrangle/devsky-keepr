<template>
  <div class="home container-fluid">
    <div class="row">
      <h1 class="col-12">Welcome to Dev-Sky's Keepr</h1>
    </div>

    <div class="row">
      <keep v-for="(keep, index) in keeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>

  <!-- <div v-if="$auth.isAuthenticated" class="home containerfluid my-bg">
    <div class="row justify-content-center">
      <div class="col-12">
        <h1 class="text-primary">Welcome to Dev-Sky's Keepr</h1>
        <h3 class="text-primary" v-if="!$auth.isAuthenticated">Log-in to access fun</h3>
        <h3 class="text-primary" v-else>You are logged-in!</h3>
      </div>
    </div>

    
  </div>

  <div v-else class="home containerfluid my-bg2">
    <div class="row justify-content-center">
      <div class="col-12">
        <h1 class="text-primary">Welcome to Dev-Sky's Keepr</h1>
        <h3 class="text-primary" v-if="!$auth.isAuthenticated">Log-in to access fun</h3>
        <h3 class="text-primary" v-else>You need to log-in!</h3>
      </div>
    </div>
  </div>-->
</template>

<script>
import Keep from "../components/Keep";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    Keep
  }
};
</script>