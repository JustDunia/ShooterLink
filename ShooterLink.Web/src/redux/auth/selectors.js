export const selectUserData = (state) => state.auth.user;
export const selectIsLoggedIn = (state) => state.auth.token != null;
export const selectIsLoading = (state) => state.auth.isLoading;
export const selectError = (state) => state.auth.error;
export const selectIsRegisteredSuccessfully = (state) =>
  state.auth.isRegisterProcessSuccessful;
