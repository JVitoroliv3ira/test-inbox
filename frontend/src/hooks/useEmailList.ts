import { useState, useEffect } from "react";
import { EmailListItem } from "@/types/output/email";
import { PaginatedResult } from "@/types/output/paginated";
import { fetchEmails } from "@/lib/email";

export function useEmailList(pageSize = 10) {
  const [result, setResult] = useState<PaginatedResult<EmailListItem>>();
  const [loading, setLoading] = useState(true);
  const [page, setPage] = useState(0);
  const [searchTerm, setSearchTerm] = useState("");

  const [debouncedSearch, setDebouncedSearch] = useState(searchTerm);

  useEffect(() => {
    const timeout = setTimeout(() => {
      setDebouncedSearch(searchTerm);
      setPage(0);
    }, 500);

    return () => clearTimeout(timeout);
  }, [searchTerm]);

  useEffect(() => {
    fetchData(page, debouncedSearch);
  }, [page, debouncedSearch]);

  const fetchData = async (page: number, term: string) => {
    setLoading(true);
    try {
      const res = await fetchEmails({ page, pageSize, searchTerm: term });
      setResult(res);
    } catch (err) {
      console.error("Erro ao buscar e-mails", err);
    } finally {
      setLoading(false);
    }
  };

  return {
    result,
    loading,
    page,
    setPage,
    searchTerm,
    setSearchTerm,
  };
}
