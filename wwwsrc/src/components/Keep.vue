<template>
  <div class="keep col-12 col-sm-6 col-md-4 col-lg-3">
    <div class="mybg" v-bind:class="{ private: keepData.isPrivate}">
      <div class="row justify-content-around">
        <div class="col-11 py-3">
          <img class="img-fluid imgs" :src="keepData.img" />
        </div>
        <div class="col-11" v-if="(keepData.name)">
          <h5>{{keepData.name}}</h5>
        </div>
        <div class="col-11" v-else>
          <h5>No Name</h5>
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
            <!-- <button @click="getVaults()">test</button> -->
          </div>
        </div>
      </div>

      <div class="row py-3 justify-content-around" v-if="$auth.isAuthenticated">
        <div class="col-3">
          <div class="btn-group">
            <button
              type="button"
              class="btn btn-secondary dropdown-toggle"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Keep</button>

            <div class="dropdown-menu bg-secondary btn text-light">
              <a
                class="dropdown-item"
                v-for="(vault, index) in vaults"
                :key="vault.id"
                @click="addKeepToVault(index)"
              >
                <!-- v-if="(vault.id!=keepData.vaultId)" -->
                <p>{{vault.name}}</p>
              </a>
            </div>
          </div>

          <!-- <button class="btn btn-secondary btn-rounded" @click="addKeepToVault()">Keep</button> -->
        </div>
        <div class="col-3">
          <button class="btn btn-warning btn-rounded">Share</button>
        </div>

        <!-- help, where is my user id vs the creator userid? -->

        <div class="col-3" v-if="(this.deleteKeep=='vault')">
          <button class="btn btn-danger btn-rounded" @click="deleteThisVK()">XVK</button>
        </div>

        <div
          class="col-3"
          v-else-if="(this.$auth.user.sub == this.keepData.userId | this.deleteKeep=='vault')"
        >
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
//import Vault from "../components/Vault";
export default {
  name: "keep",
  props: ["keepData", "keepIndex", "deleteKeep", "vaultData"],
  mounted() {
    //this.getVaults();
    //this.$store.dispatch("")
  },
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.myKeeps;
    }
  },
  methods: {
    deleteThisKeep() {
      let from = this.deleteKeep;
      let id = this.keepData.id;
      let index = this.keepIndex;
      debugger;
      if (this.vaultData != undefined) {
        debugger;
      } else {
        this.$store.dispatch("deleteKeepById", { id, index, from });
      }
    },
    deleteThisVK() {
      let keepId = this.keepData.id;
      // let vaultId = this.vaults[index].id;
      let name = this.keepData.name;
      let from = this.deleteKeep;
      let vd = this.vaultData;
      debugger;
    },
    addKeepToVault(index) {
      let keepId = this.keepData.id;
      let vaultId = this.vaults[index].id;
      let name = this.keepData.name;
      let from = this.deleteKeep;
      // debugger;
      // let oldListId = this.taskData.listId;
      this.$store.dispatch("storeKeepInVault", { keepId, vaultId, name, from });
    },

    async getVaults() {
      try {
        if (await this.$auth.isAuthenticated) {
          this.$store.dispatch("getVaults");
        }
      } catch (error) {
        console.error(error);
      }
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