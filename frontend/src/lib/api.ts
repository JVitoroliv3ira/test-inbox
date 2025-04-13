import { PaginatedQuery } from "@/types/input/paginated";
import { EmailListItem } from "@/types/output/email";
import { PaginatedResult } from "@/types/output/paginated";

export async function fetchEmails(q: PaginatedQuery): Promise<PaginatedResult<EmailListItem>> {
    const res = await fetch(`http://localhost:5247/v1/Email?Page=${q.page}&PageSize=${q.pageSize}&SearchTerm=${q.searchTerm}`);

    if (!res.ok) {
        throw new Error("Ocorreu um erro ao buscar os e-mails.");
    }

    const json = await res.json();
    return json;
}