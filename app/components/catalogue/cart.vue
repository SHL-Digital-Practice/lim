<template>
  <div
    class="max-w-sm bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700"
  >
    <div>
      <img
        class="rounded-t-lg w-full h-40 object-cover"
        :src="species.image"
        alt=""
      />
    </div>
    <div class="p-5">
      <div class="flex space-x-1">
        <template v-if="species.id === 4898">
          <div class="flex text-gray-400">
            <Icon :name="`ph:butterfly-fill`" size="1.1rem" />
          </div>
        </template>
        <template v-else-if="species.id === 4888">
          <div class="flex text-gray-400">
            <Icon :name="`game-icons:grass`" size="1.1rem" />
          </div>
        </template>
        <template v-else v-for="icon in randomIcons">
          <div class="flex text-gray-400">
            <Icon :name="icon.icon" size="1.1rem" />
          </div>
        </template>
      </div>
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

const iconsMap = [
  {
    name: "bee",
    icon: "mdi:bee",
  },
  {
    name: "butterfly",
    icon: "ph:butterfly-fill",
  },
  {
    name: "bat",
    icon: "mdi:bat",
  },
  {
    name: "bug",
    icon: "mdi:bug",
  },
  {
    name: "bird",
    icon: "mdi:bird",
  },
  {
    name: "flower",
    icon: "mdi:flower",
  },
  {
    name: "grass",
    icon: "game-icons:grass",
  },
];

function getRandomIcons(numberOfIcons = 2) {
  const count = Math.max(2, Math.min(numberOfIcons, 3));
  const selectedIcons = [];
  const indicesUsed = [];

  while (selectedIcons.length < count) {
    const randomIndex = Math.floor(Math.random() * iconsMap.length);
    if (!indicesUsed.includes(randomIndex)) {
      selectedIcons.push(iconsMap[randomIndex]);
      indicesUsed.push(randomIndex);
    }
  }

  console.log(selectedIcons);

  return selectedIcons;
}

const randomIcons = getRandomIcons();
</script>

<style scoped></style>
