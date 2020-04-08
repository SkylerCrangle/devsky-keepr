<template>
  <div class="vaults container-fluid">
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
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
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
                        <label data-error="wrong" data-success="right" for="orangeForm-name">Title</label>
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
  </div>
</template>

<script>
import Vault from "../components/Vault";
export default {
  name: "vaults",

  mounted() {
    this.getVaults();
    this.$store.dispatch("getVaults");
  },
  data() {
    return {
      newVault: {
        Name: "",
        Description: ""
      }
    };
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
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
    }
  },
  components: {
    Vault
  }
};
</script>

<style></style>
