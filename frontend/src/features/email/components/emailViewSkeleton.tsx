import {
    Card,
    CardContent,
    CardHeader,
  } from "@/components/ui/card";
  import { Skeleton } from "@/components/ui/skeleton";
  
  export function EmailViewSkeleton() {
    return (
      <Card className="w-full h-full mx-auto border-none shadow-none p-0 gap-0 space-y-3">
        <div className="flex items-center justify-end p-3 border-b-2 border-muted">
          <Skeleton className="w-8 h-8 rounded-full" />
        </div>
  
        <CardHeader className="border-b-2 border-muted p-0 pb-3 space-y-2">
          <Skeleton className="h-6 w-2/3" />
          <Skeleton className="h-4 w-1/2" />
          <Skeleton className="h-4 w-3/5" />
        </CardHeader>
  
        <CardContent className="space-y-2">
          <Skeleton className="h-4 w-full" />
          <Skeleton className="h-4 w-full" />
          <Skeleton className="h-4 w-5/6" />
          <Skeleton className="h-4 w-2/3" />
        </CardContent>
      </Card>
    );
  }
  