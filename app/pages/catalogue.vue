<template>
  <div class="w-full h-full flex justify-center">
    <div
      v-if="isLoading"
      class="fixed w-screen h-screen z-10 bg-netrual-500 backdrop-blur-sm"
    ></div>

    <div class="grid grid-cols-2 gap-6 py-6">
      <template v-for="s in species">
        <CatalogueCart
          :species="s"
          @click="selectSpecies(s)"
          class="hover:scale-105 transition-all"
        >
          <CataloguePill
            v-if="s[`Oxygen Production (kg/acre/year)`]"
            :label="s[`Oxygen Production (kg/acre/year)`] + 'kg/acre/year'"
          />
        </CatalogueCart>
      </template>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Database } from "../types/supabase";

const client = useSupabaseClient<Database>();
const isLoading = ref(false);

const { data: species, pending } = useAsyncData("species", async () => {
  const { data, error } = await client.from("species").select().limit(50);

  return data;
});

async function selectSpecies(species: any) {
  isLoading.value = true;

  // const jsonSpecies = JSON.stringify(species);

  const urlObj = await client.storage
    .from("objs")
    .createSignedUrl(species.obj, 60);

  const url = urlObj.data?.signedUrl;

  // const url = await getObjUrl(species);
  console.log(url);

  //@ts-ignore
  await chrome.webview.hostObjects.bridge.getAsset(url);
  isLoading.value = false;
}
</script>

<style scoped></style>
