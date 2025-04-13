import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { EmailCard } from "./emailCard";
import { EmailListSkeleton } from "./emailListSkeleton";
import { useEmailList } from "@/hooks/useEmailList";
import { EmailListItem } from "@/types/output/email";

interface EmailListProps {
  onCardClick: (id: number) => void
}

export function EmailList({ onCardClick }: EmailListProps) {
  const {
    result,
    loading,
    page,
    setPage,
    searchTerm,
    setSearchTerm,
  } = useEmailList();

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

    return result?.items.map((result: EmailListItem) => (
      <EmailCard key={result.id} email={result} onClick={() => { onCardClick(result.id) }} />
    ));
  };

  const renderPagination = () => {
    if (!shouldShowPagination) return null;

    return (
      <div className="flex justify-between items-center pt-2">
        <Button
          variant="outline"
          onClick={() => setPage(page - 1)}
          disabled={!result?.hasPreviousPage}
        >
          Voltar
        </Button>
        <span className="text-sm text-muted-foreground">
          Página {page + 1} de {result?.totalPages}
        </span>
        <Button
          variant="outline"
          onClick={() => setPage(page + 1)}
          disabled={!result?.hasNextPage}
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
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        disabled={loading}
      />

      {renderEmailItems()}
      {renderPagination()}
    </div>
  );
}
