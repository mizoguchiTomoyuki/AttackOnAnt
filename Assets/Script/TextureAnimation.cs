using UnityEngine;
using System.Collections;

public class TextureAnimation : MonoBehaviour {

	//public Rect rect;

	public float animationTileWidth=0,animationTileHeight=0;
	public int frameNum=0;
	public float fps=30;
	public int loop=30;
	public bool tileflag=false;
	public float TileWidth=0,TileHeight=0;
	
	private Material _material;
	private int textureWidth, textureHeight;
	private float countTime=0;
	private bool nextframeflag=false;
	private bool stopflag=false;
	private Vector2 nextframe;
	private Vector2 loopframe;
	private int loopCount;
	private int animationCount=0;
	public struct TileAnimation{
		public Vector2 TstartFrame; //初期フレームの位置,xyで指定. 
		public Vector2 TloopFrame; //ループするフレームを仕込みたいときに, 
		public int TframeNum; //アニメーションのframe数. 
		public int TloopNum; //loop回数,特に気にしないなら1を. 
		public TileAnimation(Vector2 Tstart,Vector2 Tloop,int TframeN,int TloopN){
			TstartFrame = Tstart;
			TloopFrame = Tloop;
			TframeNum = TframeN;
			TloopNum = TloopN;
		}
	};
	private TileAnimation Burn=new TileAnimation(new Vector2(1,1),new Vector2(1,1),6,1);//animation名(Burn)とそのもろもろの情報を入れておく. 
	void Start ()
	{
		
		if(!tileflag){
			TileWidth = animationTileWidth;
			TileHeight = animationTileHeight;
		}else{
			TileWidth=1/TileWidth;
			TileHeight=1/TileHeight;
		}
		loopframe = new Vector2(1,1);
		nextframe=new Vector2(1,1);

		_material = renderer.material;
		Texture texture = _material.mainTexture;
		textureWidth = texture.width;
		textureHeight = texture.height;
		
		Debug.Log(textureWidth + "/" + textureHeight);
	}
	
	void Update ()
	{
		//アニメーションを動かしている部分なので触らないように. ---------------------------------------------
		if(!stopflag)
		countTime +=Time.deltaTime;

		if(countTime>1/fps){
			nextframeflag=true;
			animationCount++;
			loopCount++;
		}
		nextframe = SetTileframe (nextframeflag,nextframe);
		if(animationCount>=frameNum){
			if(loopCount<loop*frameNum){
				nextframe = loopframe;
				animationCount=0;
			}else{
			//StopAnimation();
			nextframe = new Vector2(1,1);
			animationCount=0;
			loopCount = 0;
			}
		}
		//--------------------------------------------------------------------
	/*	for(int h=0;h<animationTileHeight;h++){
			for(int w=0;w<animationTileWidth;w++){
				Vector2 offset, scale;
		
				offset = new Vector2( w/animationTileWidth,  h/animationTileHeight);
				scale = new Vector2( 0.25f,0.5f);
				Debug.Log (offset);
				_material.SetTextureOffset("_MainTex", offset);
				_material.SetTextureScale("_MainTex", scale);
			}
		}*/
	}
	public void StopAnimation(){ //stopflagの管理を行う関数. 
		stopflag=true;
	}
	public void StartAnimation(){
		stopflag=false;
	}
	public void SwitchAnimation(){
		stopflag = !stopflag;
	}
	public Vector2 SetTileAnimation(TileAnimation TA){ //Tileアニメーションを次のSetTileframe時に再生する. 
		loopframe = TA.TloopFrame;
		loop = TA.TloopNum;
		return TA.TstartFrame;
	}
	public Vector2 GetTileFrame(int frame_x,int frame_y){ //指定フレームに移動,frame_xframe_yで移動したい位置を指定. 使う場合はnextframe=GetTileFrameで使うこと. 
		Vector2 offset,scale;
		offset = new Vector2((frame_x-1)/animationTileWidth,frame_y/animationTileHeight);
		scale = new Vector2 (1/TileWidth,1/TileHeight);
		_material.SetTextureOffset("_MainTex", offset);
		_material.SetTextureScale("_MainTex", scale);
		return new Vector2((float)frame_x,(float)frame_y);
	}
	public Vector2 SetColumn(int columnNum){ //指定カラム(縦列)に移動,1カラム1アニメーションの場合に用いる. 使う場合はnextframe=SetColumnで使うこと. 
		Vector2 offset,scale;
		offset = new Vector2(0,columnNum/animationTileHeight);
		scale = new Vector2 (1/TileWidth,1/TileHeight);
		_material.SetTextureOffset("_MainTex", offset);
		_material.SetTextureScale("_MainTex", scale);
		return new Vector2(0,(float)columnNum);

	}
	public Vector2 SetTileframe(bool flag,Vector2 next){//テクスチャのsetを行う.Updateごとに呼び出すためにフラグと次のフレームを引数とする. 使う場合はnextframe=SetTileframeで使うこと. 
		if(flag){
		//Debug.Log (nextframe);
		Vector2 offset,scale;
		offset = new Vector2((next.x-1)/animationTileWidth,next.y/animationTileHeight);
		scale = new Vector2(1/TileWidth,1/TileHeight);
		_material.SetTextureOffset("_MainTex", offset);
		_material.SetTextureScale("_MainTex", scale);
		if(next.x+1<=animationTileWidth){
			next.x++;
		}else{
			next.x=1;
			if(next.y+1<=animationTileHeight){
				next.y++;
			}else{
				next.y=1;
			}
		}
		nextframeflag = false;
		countTime = 0;
		}
		return next;
	}
}
