import { useState, useEffect } from "react";
import { EmailListItem } from "@/types/output/email";
import { PaginatedResult } from "@/types/output/paginated";
import { fetchEmails } from "@/lib/email";
import { PaginatedQuery } from "@/types/input/paginated";

export function useEmailList(query: PaginatedQuery) {
  const [result, setResult] = useState<PaginatedResult<EmailListItem> | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(true);

  const fetchData = async () => {
    setLoading(true);
    try {
      const res = await fetchEmails(query);
      setResult(res);
    } catch (err) {
      console.log(`Ocorreu um erro insperado ao buscar os e-mails: ${err}`);
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    fetchData();
  }, [query.page, query.searchTerm]);

  return {
    result,
    loading
  };
}

