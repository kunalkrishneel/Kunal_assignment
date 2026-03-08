1- How you would structure this in a larger Vue.js front-end (components, state management, etc.)src/
├── api/
│   └── machinesApi.ts          # fetch wrappers, typed response interfaces
├── stores/
│   └── machinesStore.ts        # Pinia store: state, actions, getters
├── components/
│   ├── MachineTable.vue        # presentational – receives machines[] as prop
│   ├── MachineRow.vue          # single row, emits events
│   ├── StatPill.vue            # reusable counter widget
│   └── AlertBanner.vue
├── composables/
│   └── useAutoRefresh.ts       # encapsulates setInterval / SignalR connection
├── App.vue                     # root layout shell only
└── main.ts

**Real-time:** `useAutoRefresh` would be replaced / augmented by a `useSignalR`
composable that opens a connection to the ASP.NET Core SignalR hub and patches
individual machine rows on `machineStatusUpdated` events, avoiding full re-fetches.
*useAutoRefresh- used in this sample