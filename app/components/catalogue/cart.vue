<template>
  <div
    class="max-w-sm bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700"
  >
    <div>
      <img
        class="rounded-t-lg w-full h-64 object-cover"
        :src="species.image"
        alt=""
      />
    </div>
    <div class="p-5">
      <a href="#">
        <h5 class="text-gray-900 text-xl font-bold">
          {{ species.common_name }}
        </h5>
        <h3 class="text-gray-500 text-base font-medium">
          {{ species.taxonomic_group }}
        </h3>
      </a>

      <slot> </slot>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Database } from "../../types/supabase";

type Species = Database["public"]["Tables"]["species"]["Row"];
const props = defineProps<{
  species: Species;
}>();
</script>

<style scoped></style>
