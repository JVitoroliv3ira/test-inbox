const apiUrl = import.meta.env.VITE_API_URL;

type HttpMethod = "GET" | "POST" | "PUT" | "DELETE" | "PATCH";

async function request<T, B = undefined>(
  method: HttpMethod,
  endpoint: string,
  body?: B,
  headers?: HeadersInit
): Promise<T> {
  const res = await fetch(`${apiUrl}${endpoint}`, {
    method,
    headers: {
      "Content-Type": "application/json",
      ...headers,
    },
    body: body ? JSON.stringify(body) : undefined,
  });

  if (!res.ok) {
    const errorText = await res.text();
    throw new Error(errorText || "Erro ao fazer requisição.");
  }

  return res.json();
}

export const get = <T>(endpoint: string, headers?: HeadersInit) =>
  request<T>("GET", endpoint, undefined, headers);
