import { Skeleton } from "@/components/ui/skeleton";

export function EmailListSkeleton() {
  return (
    <div className="space-y-4">
      {[...Array(10)].map((_, i) => (
        <div key={i} className="space-y-2 border rounded-md p-4">
          <Skeleton className="h-4 w-3/4" />
          <Skeleton className="h-3 w-1/2" />
          <div className="flex flex-wrap gap-2">
            {[...Array(3)].map((_, j) => (
              <Skeleton key={j} className="h-3 w-24" />
            ))}
          </div>
        </div>
      ))}
    </div>
  );
}
