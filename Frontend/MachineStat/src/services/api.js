const API_BASE = "http://localhost:5070/api";

export async function fetchMachines() {
  const response = await fetch(`${API_BASE}/machines`);

  if (!response.ok) {
    throw new Error("Failed to fetch machines");
  }

  return await response.json();
}