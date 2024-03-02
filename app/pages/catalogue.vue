<template>
  <div class="w-full h-full flex justify-center">
    <div
      v-if="isLoading"
      class="fixed w-screen h-screen z-10 bg-netrual-500 backdrop-blur-sm"
    ></div>

    <div class="grid grid-cols-2 gap-6">
      <template v-for="s in species">
        <CatalogueCart
          :species="s"
          @click="selectSpecies(s)"
          class="hover:scale-105 transition-all"
        >
          <CataloguePill :label="'25 kg co2/yearly'" />
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
  console.log(species);

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
