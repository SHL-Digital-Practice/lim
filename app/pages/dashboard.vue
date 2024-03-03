<template>
  <ClientOnly>
    <div class="bg-gray-100 flex flex-col items-center min-h-screen p-6">
      <div
        class="w-full bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700"
      >
        <DonutChart />
      </div>
      <Stats class="w-full" />
    </div>
  </ClientOnly>
</template>

<script setup lang="ts">
import DonutChart from "~/components/DonutChart.vue";

const species = useSpecies();

watch(species, (newValue) => {
  console.log("species changed", newValue);
});

onMounted(async () => {
  if (window.chrome.webview) {
    window.chrome.webview.addEventListener("message", async (event: any) => {
      const message = event.data;
      console.log("message type: " + message.type);
      if (message.type == "loadObject") {
        return;
      }

      if (message.type == "unloadAll") {
        return;
      }

      if (message.type == "speciesData") {
        console.log("speciesData");
        const placedInstances = message.data;

        if (placedInstances.length > 0) {
          species.value = placedInstances;
        }
        console.log("placedInstances", placedInstances);
      }

      if (message.type == "removeAllSpecies") {
        console.log("removeAllSpecies");
      }
    });
  }
});
</script>
