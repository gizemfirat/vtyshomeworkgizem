class Result<T> {
  isSuccess!: boolean;
  message?: string;
  data?: T;
}

export default Result;