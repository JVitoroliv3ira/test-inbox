export interface EmailListItem {
  id: number;
  from?: string;
  to?: string[];
  subject?: string;
}

export interface EmailDetails {
  id: number;
  from?: string;
  to?: string[];
  subject?: string;
  body?: string;
}
