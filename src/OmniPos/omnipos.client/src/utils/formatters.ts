export const formatCurrency = (value: number): string => {
  if (value === undefined || value === null) return '0 ₫';
  return new Intl.NumberFormat('vi-VN', { 
    style: 'currency', 
    currency: 'VND' 
  }).format(value);
};

export const formatDate = (date: string): string => {
  return new Date(date).toLocaleDateString('vi-VN');
};
