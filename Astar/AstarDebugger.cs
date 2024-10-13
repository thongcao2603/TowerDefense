// using UnityEngine;

// public class AstarDebugger
// {
//   [SerializeField]
//   private TileScript start, goal;

//   private void Update()
//   {
//     ClickTile();
//   }
//   private void ClickTile()
//   {
//     if (Input.GetMouseButtonDown(1))
//     {
//       RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//       if (hit.collider != null)
//       {
//         TileScript tmp = hit.collider.GetComponent<TileScript>();
//         if (tmp != null)
//         {
//           if (start == null)
//           {
//             start = tmp;
//           } else if (goal ==null)
//           {
//             goal = tmp;
//           }
//         }
//       }
//     }
//   }
// }
