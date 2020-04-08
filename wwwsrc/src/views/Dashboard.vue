<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
      <div class="col-6">
        <!-- <router-link to="/keeps"> -->
        <button class="btn btn-dark" @click="setShow('keeps')">See all your Keeps</button>
        <!-- </router-link> -->
      </div>
      <div class="col-6">
        <!-- <router-link to="/vaults"> -->
        <button class="btn btn-dark" @click="setShow('vaults')">See your Vaults</button>
        <!-- </router-link> -->
      </div>

      <div class="row" v-if="this.show === 'vaults'">
        <div class="col-12">
          <div class="row">
            <div class="col-12">
              <h1>These are your vaults</h1>
              <!-- <button @click="getVaults()">reveal</button> -->
            </div>

            <div class="col-12">
              <div class="createvault row">
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
                          <h4 class="modal-title w-100 font-weight-bold">Make your vault</h4>
                          <button
                            type="button"
                            class="close"
                            data-dismiss="modal"
                            aria-label="Close"
                          >
                            <span aria-hidden="true">&times;</span>
                          </button>
                        </div>

                        <form @submit.prevent="addVault">
                          <div class="modal-body mx-3">
                            <div class="md-form mb-5">
                              <i class="fas fa-user prefix grey-text"></i>
                              <input
                                type="text"
                                id="orangeForm-name"
                                class="form-control validate"
                                placeholder="title"
                                v-model="newVault.Name"
                              />
                              <label
                                data-error="wrong"
                                data-success="right"
                                for="orangeForm-name"
                              >Title</label>
                            </div>

                            <div class="md-form mb-5">
                              <i class="fas fa-user prefix grey-text"></i>
                              <input
                                type="text"
                                id="orangeForm-name"
                                class="form-control validate"
                                placeholder="description"
                                v-model="newVault.Description"
                              />
                              <label
                                data-error="wrong"
                                data-success="right"
                                for="orangeForm-name"
                              >Description</label>
                            </div>
                          </div>

                          <div class="modal-footer d-flex justify-content-center">
                            <button class="btn btn-deep-orange close" type="submit">Create</button>
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
                    >Make a new Vault</a>
                  </div>
                  <!--end create vault -->
                </div>
              </div>
              <!-- end -->
            </div>

            <div class="col-12">
              <vault v-for="(vault, index) in vaults" :key="vault.id" :vaultData="vault" />
            </div>
          </div>

          <!-- end vaults -->
        </div>
      </div>
      <!-- end vaults -->

      <div class="row" v-if="this.show === 'keeps'">
        <div class="col-12">
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
                          <label
                            data-error="wrong"
                            data-success="right"
                            for="orangeForm-name"
                          >Description</label>
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
                          <label
                            data-error="wrong"
                            data-success="right"
                            for="orangeForm-name"
                          >Img Url:</label>
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
        </div>
        <!-- end -->

        <keep v-for="(keep, index) in keeps" :key="keep.id" :keepData="keep" />

        <!-- end all keeps -->
      </div>
      <!-- end all keeps -->

      <div class="row">
        <div class="col-12" v-if="this.show === ''">
          <p>option 3</p>
        </div>
      </div>
    </div>
  </div>

  <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
</template>

<script>
import Vault from "../components/Vault";
import Keep from "../components/Keep";
export default {
  mounted() {
    this.getVaults();
    this.getKeeps();
    // this.$store.dispatch("getVaults");
    //this.$store.dispatch("setKeeps");
  },
  data() {
    return {
      newVault: {
        Name: "",
        Description: ""
      },
      newKeep: {
        Name: "",
        Description: "",
        Img: "",
        IsPrivate: false
      }
    };
  },
  computed: {
    show() {
      return this.$store.state.show;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.myKeeps;
    }
  },
  methods: {
    setShow(show) {
      this.$store.dispatch("setShow", show);
    },
    async getVaults() {
      try {
        if (await this.$auth.isAuthenticated) {
          this.$store.dispatch("getVaults");
        }
      } catch (error) {
        console.error(error);
      }
    },
    addVault() {
      let thing = this.newVault;
      this.$store.dispatch("addVault", thing);
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
    },
    addKeep() {
      let thing = this.newKeep;
      this.$store.dispatch("addKeep", thing);
      $("#modalRegisterForm").modal("hide");
    }
  },
  components: {
    Vault,
    Keep
  }
};
</script>

<style></style>
