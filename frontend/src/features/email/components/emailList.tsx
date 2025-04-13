import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { EmailCard } from "./emailCard";
import { EmailListSkeleton } from "./emailListSkeleton";
import { useEmailList } from "@/hooks/useEmailList";
import { EmailListItem } from "@/types/output/email";
import { useState } from "react";
import { PaginatedQuery } from "@/types/input/paginated";
import { useDebouncedValue } from "@/hooks/useDebouncedValue";

interface EmailListProps {
  onCardClick: (id: number) => void;
}

export function EmailList({ onCardClick }: EmailListProps) {
  const [query, setQuery] = useState<PaginatedQuery>({
    page: 0,
    pageSize: 10,
    searchTerm: "",
  });

  const debouncedSearchTerm = useDebouncedValue(query.searchTerm, 500);
  const debouncedQuery = { ...query, searchTerm: debouncedSearchTerm };
  const { result, loading } = useEmailList(debouncedQuery);

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setQuery({
      ...query,
      searchTerm: e.target.value,
      page: 0,
    });
  };

  const handlePageChange = (newPage: number) => {
    setQuery({
      ...query,
      page: newPage,
    });
  };

  const shouldShowEmptyState = !loading && (!result || result.items.length === 0);
  const shouldShowPagination = !loading && result && result.totalPages > 1;

  const renderEmailItems = () => {
    if (loading) return <EmailListSkeleton />;
    if (shouldShowEmptyState) {
      return (
        <div className="flex justify-center items-center p-3">
          <p className="text-sm text-muted-foreground">Nenhum e-mail encontrado.</p>
        </div>
      );
    }

    return result?.items.map((email: EmailListItem) => (
      <EmailCard key={email.id} email={email} onClick={() => onCardClick(email.id)} />
    ));
  };

  const renderPagination = () => {
    if (!shouldShowPagination) return null;

    return (
      <div className="flex justify-between items-center pt-2">
        <Button
          variant="outline"
          onClick={() => handlePageChange(query.page - 1)}
          disabled={!result.hasPreviousPage}
        >
          Voltar
        </Button>
        <span className="text-sm text-muted-foreground">
          Página {result.page + 1} de {result.totalPages}
        </span>
        <Button
          variant="outline"
          onClick={() => handlePageChange(query.page + 1)}
          disabled={!result.hasNextPage}
        >
          Avançar
        </Button>
      </div>
    );
  };

  return (
    <div className="flex flex-col space-y-4">
      <Input
        placeholder="Buscar e-mails..."
        value={query.searchTerm}
        onChange={handleSearchChange}
        disabled={loading}
      />

      {renderEmailItems()}
      {renderPagination()}
    </div>
  );
}
