<template>

  <div class="container">
    <h1>Smart Vending Dashboard</h1>

    <div class="stats">
      <div class="stat-box">
        <strong>Total Machines:</strong> {{ totalMachines }}
      </div>

      <div class="stat-box alert">
        <strong>Machines in Alert:</strong> {{ alertMachines }}
      </div>
    </div>

    <table>
      <thead>
        <tr>
          <th>Machine ID</th>
          <th>Status</th>
          <th>Temperature (°C)</th>
          <th>Last Error</th>
        </tr>
      </thead>

      <tbody>
        <tr
          v-for="machine in machines"
          :key="machine.machineId"
          :class="{ alertRow: machine.hasAlert }"
        >
          <td>{{ machine.machineId }}</td>
          <td>{{ machine.status }}</td>
          <td>{{ machine.temperatureC }}</td>
          <td>{{ machine.lastErrorCode || "-" }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { fetchMachines } from "./services/api";

export default {
  data() {
    return {
      machines: [],
    };
  },

  computed: {
    totalMachines() {
      return this.machines.length;
    },

    alertMachines() {
      return this.machines.filter((m) => m.hasAlert).length;
    },
  },

  async mounted() {
    try {
      this.machines = await fetchMachines();
      // Auto refresh every 10 seconds
    setInterval(async () => {
      this.machines = await fetchMachines();
    }, 10000);
    } catch (error) {
      console.error(error);
    }
  },
};
</script>

<style>
.container {
  font-family: Arial, Helvetica, sans-serif;
  margin: 40px;
}

h1 {
  margin-bottom: 20px;
}

.stats {
  display: flex;
  gap: 20px;
  margin-bottom: 20px;
}

.stat-box {
  padding: 10px 20px;
  background: #eee;
  border-radius: 5px;
}

.alert {
  background: #ffdddd;
}

table {
  border-collapse: collapse;
  width: 100%;
}

th,
td {
  padding: 10px;
  border-bottom: 1px solid #ccc;
}

.alertRow {
  background-color: #ffe6e6;
  font-weight: bold;
}
</style>