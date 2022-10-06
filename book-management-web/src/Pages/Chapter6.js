import React, { useState } from 'react'
import ColorList from '../components/ColorApp/ColorList'
import AddColorForm from '../components/ColorApp/AddColorForm'
import {v4} from 'uuid'

import ReactMarkdown from 'react-markdown'
import remarkGfm from 'remark-gfm'

const markdown = `
## 6. ステート管理
8
### StarRating compoennt
ルートコンポーネントでステート管理をするようにする。
StarRatingはステートを持たない純粋関数とする。

StarRating：選択された星マークに色がつく

Color：色情報とStarRatingコンポーネントを中にもつ

ColorList：Colorオブジェクトを受け取って、オブジェクトの数分のColorコンポーネントを描画する

### クリックイベントに反応させてStarの色を変える

### アプリケーション全体のステート管理
`

const colorData = [
  {
    id: 1,
    title: 'ocean at duck',
    color: '#00c4e2',
    rating: 3,
  },
  {
    id: 2,
    title: 'lawn',
    color: '#26ac56',
    rating: 5,
  },
  {
    id: 3,
    title: 'bright red',
    color: '#ff0000',
    rating: 1,
  },
]
function Chapter6() {
  const [colors, setColors] = useState(colorData)

  return (
    <div>
      <ReactMarkdown children={markdown} remarkPlugins={[remarkGfm]} />
      <AddColorForm
          onNewColor={(title, color) => {
            const newColors =[
              ...colors,
              {
                id: v4(),
                rating: 0,
                title,
                color
              }
            ];
            setColors(newColors)
          }} />
      <ColorList
        colors={colors}
        onRateColor={(id, rating) => {
          const newColors = colors.map((color) =>
            color.id === id ? { ...color, rating } : color
          )
          setColors(newColors)
        }}
        onRemoveColor={(id) => {
          const newColors = colors.filter((color) => color.id !== id)
          setColors(newColors)
        }}
      />
    </div>
  )
}

export default Chapter6
