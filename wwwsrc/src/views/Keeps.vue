<template>
  <div class="home container-fluid">
    <div class="row">
      <h1 class="col-12">Welcome to Dev-Sky's Keepr</h1>
      <h4 class="col-8">Here you can see all of the public keeps</h4>
    </div>

    <div class="createkeep row">
      <div class="col-12">
        <div
          class="modal fade"
          id="modalRegisterForm"
          tabindex="-1"
          role="dialog"
          aria-labelledby="myModalLabel"
          aria-hidden="true"
        >
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header text-center">
                <h4 class="modal-title w-100 font-weight-bold">What do you want to Keep?</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <form @submit.prevent="addKeep">
                <div class="modal-body mx-3">
                  <div class="md-form mb-5">
                    <i class="fas fa-user prefix grey-text"></i>
                    <input
                      type="text"
                      id="orangeForm-name"
                      class="form-control validate"
                      placeholder="title"
                      v-model="newKeep.Name"
                      required
                    />
                    <label data-error="wrong" data-success="right" for="orangeForm-name">Title</label>
                  </div>

                  <div class="md-form mb-5">
                    <i class="fas fa-user prefix grey-text"></i>
                    <input
                      type="text"
                      id="orangeForm-name"
                      class="form-control validate"
                      placeholder="description"
                      v-model="newKeep.Description"
                      required
                    />
                    <label data-error="wrong" data-success="right" for="orangeForm-name">Description</label>
                  </div>

                  <div class="md-form mb-5">
                    <i class="fas fa-user prefix grey-text"></i>
                    <input
                      type="text"
                      id="orangeForm-name"
                      class="form-control validate"
                      placeholder="imgage url"
                      v-model="newKeep.Img"
                      required
                    />
                    <label data-error="wrong" data-success="right" for="orangeForm-name">Img Url:</label>
                  </div>

                  <div class="md-form mb-5">
                    <i class="fas fa-user prefix grey-text"></i>
                    <input
                      type="checkbox"
                      id="vehicle1"
                      name="vehicle1"
                      value="Bike"
                      v-model="newKeep.IsPrivate"
                    />
                    <label for="vehicle1">Check to make it Private</label>
                  </div>
                </div>

                <div class="modal-footer d-flex justify-content-center">
                  <button class="btn btn-deep-orange" type="submit">Create</button>
                </div>
              </form>
            </div>
          </div>
        </div>

        <div v-if="$auth.isAuthenticated" class="text-right">
          <a
            href
            class="btn btn-default btn-dark btn-rounded mb-4"
            data-toggle="modal"
            data-target="#modalRegisterForm"
          >Post a new Keep</a>
        </div>
        <!--end create keep -->
      </div>
    </div>
    <!-- end -->

    <div class="row">
      <button
        v-if="$auth.isAuthenticated"
        class="col-12 btn btn-dark"
        @click="removePublicKeeps()"
      >Remove the public Keeps</button>
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
// v-model="selectedInventoryItem.title"
export default {
  name: "keeps",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.getKeeps();
    //this.$store.dispatch("getMyKeeps");
    //setTimeout(this.$store.dispatch("getMyKeeps", 4000));
  },
  data() {
    return {
      newKeep: {
        Name: "",
        Description: "",
        Img: "",
        IsPrivate: false
      }
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      let allTheKeeps = [];
      let arr1 = this.$store.state.keeps;
      let arr2 = this.$store.state.myKeeps;
      for (let i = 0; i < arr1.length; i++) {
        allTheKeeps.push(arr1[i]);
      }
      for (let i = 0; i < arr2.length; i++) {
        allTheKeeps.push(arr2[i]);
      }
      return allTheKeeps;

      // return this.$store.state.keeps;
      // return this.$store.state.myKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addKeep() {
      let thing = this.newKeep;
      // debugger;
      this.$store.dispatch("addKeep", thing);
    },
    async getKeeps() {
      //debugger;
      try {
        // let thing = await this.$auth.isAuthenticated;
        if (await this.$auth.isAuthenticated) {
          // debugger;
          this.$store.dispatch("getMyKeeps");
        }
      } catch (error) {
        console.error(error);
      }

      //setTimeout(this.$store.dispatch("getMyKeeps", 4000));
    },
    removePublicKeeps() {
      let thing = this.keeps;
      thing = thing.filter(t => t.isPrivate == false);
      console.log(thing);
      // this.keeps = thing;
      // return this.keeps;
    }
  },
  components: {
    Keep
  }
};
</script>