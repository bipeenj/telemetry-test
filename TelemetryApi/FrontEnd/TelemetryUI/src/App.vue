
<template>
  <div>
<h2>Machines</h2>

<p>Total Machines: {{ machines.length }}</p>
<p>Machines In Alert: {{ alertCount }}</p>

<table border="1">
<tr>
<th>Machine ID</th>
<th>Status</th>
<th>Temperature</th>
<th>Error Code</th>
</tr>

<tr v-for="m in machines" :key="m.MachineId"
    :style="{background: m.HasAlert ? '#ffcccc' : ''}">
  <td>{{ m.MachineId }}</td>
  <td>{{ m.LatestStatus }}</td>
  <td>{{ m.LatestTemperatureC }}</td>
  <td>{{ m.LatestLastErrorCode }}</td>
</tr>


</table>

</div>
</template>
<script setup lang="ts">
import { ref, computed, onMounted } from 'vue'

interface Machine {
  MachineId: string
  LatestStatus: string
  LatestTemperatureC: number
  LatestLastErrorCode: string
  HasAlert: boolean
}

const machines = ref<Machine[]>([])

const alertCount = computed(() => machines.value.filter(m => m.HasAlert).length)

onMounted(async () => {
  const data = await fetch('/api/machines').then(r => r.json())
  machines.value = data.map((m: any) => ({
    MachineId: m.machineId,
    LatestStatus: m.latestStatus,
    LatestTemperatureC: m.latestTemperatureC,
    LatestLastErrorCode: m.LatestLastErrorCode,
    HasAlert: m.hasAlert
  }))
})
</script>
<style scoped></style>
