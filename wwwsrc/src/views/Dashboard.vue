<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <div class="col-6">
        <router-link to="/keeps">
          <button class="btn btn-dark">See all the Keeps</button>
        </router-link>
      </div>
      <div class="col-6">
        <router-link to="/vaults">
          <button class="btn btn-dark">See your Vaults</button>
        </router-link>
      </div>
    </div>

    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
  </div>
</template>

<script>
export default {
  mounted() {},
  computed: {}
};
</script>

<style></style>
