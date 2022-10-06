import React from 'react'

import { useFetch } from '../hooks'

import ReactMarkdown from 'react-markdown'
import remarkGfm from 'remark-gfm'

const markdown = `
## 8. データ

### データの受信
GitHubではユーザーアカウントの情報をAPI経由で取得することができる

### 仮想リスト
画面で見えていない部分も余分で読み込むことによって無限スクロールを実装する。

### 複数リクエスト
複数のAPIを叩いて、合成して表示する処理はどのアプリケーションでも使われるので抑えておくこと。
`

function GitHubUser(login) {
  return (
    <Fetch
      uri={`https://api.github.com/users/${login}`}
      renderSuccess={UserDetails}
    />
  )
}

function UserDetails({ data }) {
  return (
    <div className='githubUser'>
      <img src={data.avatar_url} alt={data.login} style={{ width: 200 }} />
      <div>
        <h1>{data.login}</h1>
        {data.name && <p>{data.name}</p>}
        {data.location && <p>{data.location}</p>}
      </div>
    </div>
  )
}

function Fetch({
  uri,
  renderSuccess,
  loadingFallback = <p>loading...</p>,
  renderError = (error) => <pre>{JSON.stringify(error, null, 2)}</pre>,
}) {
  const { loading, data, error } = useFetch(uri)
  if (error) return renderError(error)
  if (loading) return loadingFallback
  if (data) return renderSuccess({ data })
}

function Chapter8() {
  const renderItem = (item) => (
    <div style={{ display: 'flex' }}>
      <img src={item.avator} alt={item.name} width={50} />
      <p>
        {item.name} - {item.email}
      </p>
    </div>
  )

  return (
    <div>
      <ReactMarkdown children={markdown} remarkPlugins={[remarkGfm]} />
      {GitHubUser('koki-2424')}
    </div>
  )
}

export default Chapter8
