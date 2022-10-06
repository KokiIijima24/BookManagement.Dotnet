import React, { useState } from 'react'
import CheckBox from '../components/Utils/CheckBox'

import ReactMarkdown from 'react-markdown'
import remarkGfm from 'remark-gfm'

const markdown = `
## 7. フック

### useReducerを使ったステート管理
useStateの代わりにuseReduceを使うとステート更新のロジックを抽象化できる
`

function Chapter7() {
  return (
    <div>
      <ReactMarkdown children={markdown} remarkPlugins={[remarkGfm]} />
      <div>
        <CheckBox />
      </div>
    </div>
  )
}

export default Chapter7
