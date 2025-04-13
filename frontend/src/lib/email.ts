import { PaginatedQuery } from "@/types/input/paginated";
import { EmailListItem } from "@/types/output/email";
import { PaginatedResult } from "@/types/output/paginated";
import { get } from "./api";

export async function fetchEmails(q: PaginatedQuery): Promise<PaginatedResult<EmailListItem>> {
  const params = new URLSearchParams({
    Page: String(q.page),
    PageSize: String(q.pageSize),
    SearchTerm: q.searchTerm || "",
  });

  return get<PaginatedResult<EmailListItem>>(`/Email?${params.toString()}`)
}
