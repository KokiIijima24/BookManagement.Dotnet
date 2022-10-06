import { createSlice } from '@reduxjs/toolkit'
import axios from 'axios'

const initialState = {
  user: null, // ユーザー情報の格納場所
}

const slice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setUser: (state, action) => {
      return Object.assign({}, state, { user: action.payload })
    },
    signOut: (state) => {
      return Object.assign({}, state, { user: null })
    },
  },
})

export default slice.reducer

// 認証済みか確認するセレクター
export const isAuthSelector = (state) => {
  return state.auth.user !== null
}

// ログイン機能
export function login(username, password) {
  return async function (dispatch) {
    //const user = await loginApi(username, password)
    let body = { email: username, password: password }
    axios
      .post('https://localhost:5001/api/account/login', body)
      .then(async (response) => {
        localStorage.setItem('TOKEN', response.data.token);
        // ログイン後にユーザー情報をストアに格納する
        dispatch(slice.actions.setUser(response.data))
      })
  }　　　　　　　　　　　　　　　　　　　　　　　　　
}

// サインアウト
export function logout() {
  return async function (dispatch) {
    dispatch(slice.actions.signOut([]))
  }
}
