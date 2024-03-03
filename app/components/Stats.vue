<template>
  <div>
    <dl
      class="mt-5 grid grid-cols-1 divide-y divide-gray-200 overflow-hidden rounded-lg bg-white shadow md:grid-cols-3 md:divide-x md:divide-y-0"
    >
      <div v-for="item in stats" :key="item.name" class="px-4 py-5 sm:p-6">
        <dt class="text-base font-normal text-gray-900">
          <h5
            class="text-xl font-semibold leading-none text-gray-900 dark:text-white pe-1"
          >
            {{ item.name }}
          </h5>
        </dt>
        <dd class="mt-1 flex items-baseline justify-between md:block lg:flex">
          <div class="flex items-baseline text-2xl font-bold text-green-600">
            {{ item.stat }}
            <span class="ml-2 text-sm font-medium text-gray-500"
              >from {{ item.previousStat }}</span
            >
          </div>

          <div
            :class="[
              item.changeType === 'increase'
                ? 'bg-green-100 text-green-800'
                : 'bg-red-100 text-red-800',
              'inline-flex items-baseline rounded-full px-2.5 py-0.5 text-sm font-medium md:mt-2 lg:mt-0',
            ]"
          >
            <ArrowUpIcon
              v-if="item.changeType === 'increase'"
              class="-ml-1 mr-0.5 h-5 w-5 flex-shrink-0 self-center text-green-500"
              aria-hidden="true"
            />
            <ArrowDownIcon
              v-else
              class="-ml-1 mr-0.5 h-5 w-5 flex-shrink-0 self-center text-red-500"
              aria-hidden="true"
            />
            <span class="sr-only">
              {{ item.changeType === "increase" ? "Increased" : "Decreased" }}
              by
            </span>
            {{ item.change }}
          </div>
        </dd>
      </div>
    </dl>
  </div>
</template>

<script setup lang="ts">
import { ArrowDownIcon, ArrowUpIcon } from "@heroicons/vue/20/solid";

const stats = [
  {
    name: "CO2 absorption/yr",
    stat: "2,340 kg",
    previousStat: "1,946 kg",
    change: "12%",
    changeType: "increase",
  },
  {
    name: "Number of species planted",
    stat: "14",
    previousStat: "13",
    change: "2.02%",
    changeType: "increase",
  },
  {
    name: "Wild Life Protection",
    stat: "24.57%",
    previousStat: "28.62%",
    change: "4.05%",
    changeType: "decrease",
  },
];
</script>

<style scoped></style>
