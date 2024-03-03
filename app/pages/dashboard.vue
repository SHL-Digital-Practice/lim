<template>
  <div class="bg-gray-100 flex flex-col items-center min-h-screen p-6">
    <div
      class="w-full bg-white border border-gray-200 rounded-lg shadow hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700"
    >
      <ClientOnly>
        <DonutChart />
      </ClientOnly>
    </div>
  </div>
</template>

<script setup lang="ts">
import DonutChart from "~/components/DonutChart.vue";
</script>
