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
                      v-model="newKeep.name"
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
                      v-model="newKeep.description"
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
                      v-model="newKeep.img"
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
                      v-model="newKeep.isPrivate"
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
      <keep v-for="(keep, index) in keeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>




<script>
import Keep from "../components/Keep";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.getKeeps();
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: false
      }
    };
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
    },
    addKeep() {
      let thing = this.newKeep;
      this.$store.dispatch("addKeep", thing);
      $("#modalRegisterForm").modal("hide");
    },
    async getKeeps() {
      try {
        if (await this.$auth.isAuthenticated) {
          this.$store.dispatch("getMyKeeps");
        }
      } catch (error) {
        console.error(error);
      }
    }
  },
  components: {
    Keep
  }
};
</script>