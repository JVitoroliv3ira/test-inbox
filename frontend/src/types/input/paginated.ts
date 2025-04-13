export interface PaginatedQuery {
    page: number;
    pageSize: number;
    sortBy?: string;
    sortDirection?: string;
    searchTerm?: string;
}